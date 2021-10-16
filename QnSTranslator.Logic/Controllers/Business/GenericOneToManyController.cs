//@QnSCodeCopy
//MdStart
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CommonBase.Extensions;
using CommonBase.Helpers;
using QnSTranslator.Logic.Exceptions;

namespace QnSTranslator.Logic.Controllers.Business
{
    internal abstract partial class GenericOneToManyController<I, E, TFirst, TFirstEntity, TSecond, TSecondEntity> : ControllerObject, Contracts.Client.IControllerAccess<I>
		where I : Contracts.IOneToMany<TFirst, TSecond>
		where E : Entities.OneToManyObject<TFirst, TFirstEntity, TSecond, TSecondEntity>, I, Contracts.ICopyable<I>, new()
		where TFirst : Contracts.IIdentifiable, Contracts.ICopyable<TFirst>
		where TFirstEntity : Entities.IdentityObject, TFirst, Contracts.ICopyable<TFirst>, new()
		where TSecond : Contracts.IIdentifiable, Contracts.ICopyable<TSecond>
		where TSecondEntity : Entities.IdentityObject, TSecond, Contracts.ICopyable<TSecond>, new()
	{
		static GenericOneToManyController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();

		protected abstract GenericController<TFirst, TFirstEntity> OneEntityController { get; set; }
		protected abstract GenericController<TSecond, TSecondEntity> ManyEntityController { get; set; }

		public virtual int MaxPageSize => OneEntityController.MaxPageSize;

		public GenericOneToManyController(DataContext.IContext context) : base(context)
		{
			Constructing();
			ChangedSessionToken += GenericOneToManyController_ChangedSessionToken;
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public GenericOneToManyController(ControllerObject controller) : base(controller)
		{
			Constructing();
			ChangedSessionToken += GenericOneToManyController_ChangedSessionToken;
			Constructed();
		}

		private void GenericOneToManyController_ChangedSessionToken(object sender, EventArgs e)
		{
			OneEntityController.SessionToken = SessionToken;
			ManyEntityController.SessionToken = SessionToken;
		}

		protected E ConvertTo(I contract)
		{
			contract.CheckArgument(nameof(contract));

			E result = new E();

			result.CopyProperties(contract);
			return result;
		}
		protected IEnumerable<E> ConvertTo(IEnumerable<I> contracts)
		{
			contracts.CheckArgument(nameof(contracts));

			List<E> result = new List<E>();

			foreach (var item in contracts)
			{
				result.Add(ConvertTo(item));
			}
			return result;
		}

		public virtual Task<int> CountAsync()
		{
			return OneEntityController.CountAsync();
		}
		public virtual Task<int> CountByAsync(string predicate)
		{
			return OneEntityController.CountByAsync(predicate);
		}
		#region Async-Methods
		protected virtual PropertyInfo GetNavigationToOne()
		{
			return typeof(TSecondEntity).GetProperty(typeof(TFirstEntity).Name);
		}
		protected virtual PropertyInfo GetForeignKeyToOne()
		{
			return typeof(TSecond).GetProperty($"{typeof(TFirstEntity).Name}Id");
		}
		protected virtual async Task LoadDetailsAsync(E entity, int masterId)
		{
			var predicate = $"{typeof(TFirstEntity).Name}Id == {masterId}";

			entity.ClearManyItems();
			foreach (var item in (await ManyEntityController.QueryAllAsync(predicate).ConfigureAwait(false)).ToList())
			{
				entity.AddManyItem(item);
			}
		}
		protected virtual async Task<IEnumerable<TSecondEntity>> QueryDetailsAsync(int masterId)
		{
			var result = new List<TSecondEntity>();
			var predicate = $"{typeof(TFirstEntity).Name}Id == {masterId}";

			foreach (var item in (await ManyEntityController.QueryAllAsync(predicate).ConfigureAwait(false)).ToList())
			{
				var e = new TSecondEntity();

				e.CopyProperties(item);
				result.Add(e);
			}
			return result;
		}
		public virtual async Task<I> GetByIdAsync(int id)
		{
			var result = default(E);
			var firstEntity = await OneEntityController.GetByIdAsync(id).ConfigureAwait(false);

			if (firstEntity != null)
			{
				result = new E();
				result.OneItem.CopyProperties(firstEntity);
				await LoadDetailsAsync(result, firstEntity.Id).ConfigureAwait(false);
			}
			else
			{
				throw new LogicException(ErrorType.InvalidId);
			}
			return result;
		}
		public virtual Task<IQueryable<I>> GetPageListAsync(int pageIndex, int pageSize)
		{
			return Task.Run(async () =>
			{
				List<I> result = new List<I>();

				foreach (var item in (await OneEntityController.GetPageListAsync(pageIndex, pageSize).ConfigureAwait(false)).ToList())
				{
					E entity = new E();

					entity.OneItem.CopyProperties(item);
					await LoadDetailsAsync(entity, item.Id).ConfigureAwait(false);

					result.Add(entity);
				}
				return result.AsQueryable();
			});
		}
		public virtual Task<IQueryable<I>> GetAllAsync()
		{
			return Task.Run(async () =>
			{
				List<I> result = new List<I>();

				foreach (var item in (await OneEntityController.GetAllAsync().ConfigureAwait(false)).ToList())
				{
					E entity = new E();

					entity.OneItem.CopyProperties(item);
					await LoadDetailsAsync(entity, item.Id).ConfigureAwait(false);

					result.Add(entity);
				}
				return result.AsQueryable();
			});
		}

		public virtual Task<IQueryable<I>> QueryPageListAsync(string predicate, int pageIndex, int pageSize)
		{
			return Task.Run(async () =>
			{
				List<I> result = new List<I>();

				foreach (var item in (await OneEntityController.QueryPageListAsync(predicate, pageIndex, pageSize).ConfigureAwait(false)).ToList())
				{
					E entity = new E();

					entity.OneItem.CopyProperties(item);
					await LoadDetailsAsync(entity, item.Id).ConfigureAwait(false);

					result.Add(entity);
				}
				return result.AsQueryable();
			});
		}
		public virtual Task<IQueryable<I>> QueryAllAsync(string predicate)
		{
			return Task.Run(async () =>
			{
				List<I> result = new List<I>();

				foreach (var item in (await OneEntityController.QueryAllAsync(predicate).ConfigureAwait(false)).ToList())
				{
					E entity = new E();

					entity.OneItem.CopyProperties(item);
					await LoadDetailsAsync(entity, item.Id).ConfigureAwait(false);

					result.Add(entity);
				}
				return result.AsQueryable();
			});
		}

		public virtual Task<I> CreateAsync()
		{
			return Task.Run<I>(() => new E());
		}

		public virtual async Task<I> InsertAsync(I entity)
		{
			entity.CheckArgument(nameof(entity));
			entity.OneItem.CheckArgument(nameof(entity.OneItem));
			entity.ManyItems.CheckArgument(nameof(entity.ManyItems));

			var result = new E();

			result.FirstEntity.CopyProperties(entity.OneItem);
			await OneEntityController.InsertAsync(result.FirstEntity).ConfigureAwait(false);

			foreach (var item in entity.ManyItems)
			{
				var secondEntity = new TSecondEntity();

				secondEntity.CopyProperties(item);

				var pi = GetNavigationToOne();

				if (pi != null)
				{
					pi.SetValue(secondEntity, result.FirstEntity);
				}
				await ManyEntityController.InsertAsync(secondEntity).ConfigureAwait(false);
				result.AddManyItem(secondEntity);
			}
			return result;
		}

		public virtual async Task<I> UpdateAsync(I entity)
		{
			entity.CheckArgument(nameof(entity));
			entity.OneItem.CheckArgument(nameof(entity.OneItem));
			entity.ManyItems.CheckArgument(nameof(entity.ManyItems));

			//Delete all costs that are no longer included in the list.
			foreach (var item in (await QueryDetailsAsync(entity.Id).ConfigureAwait(false)).ToList())
			{
				var exitsItem = entity.ManyItems.SingleOrDefault(i => i.Id == item.Id);

				if (exitsItem == null)
				{
					await ManyEntityController.DeleteAsync(item.Id).ConfigureAwait(false);
				}
			}

			var result = new E();
			var firstEntity = await OneEntityController.UpdateAsync(entity.OneItem).ConfigureAwait(false);

			result.OneItem.CopyProperties(firstEntity);
			foreach (var item in entity.ManyItems)
			{
				if (item.Id == 0)
				{
					var pi = GetForeignKeyToOne();

					if (pi != null)
					{
						pi.SetValue(item, firstEntity.Id);
					}
					var insDetail = await ManyEntityController.InsertAsync(item).ConfigureAwait(false);

					item.CopyProperties(insDetail);
				}
				else
				{
					var updDetail = await ManyEntityController.UpdateAsync(item).ConfigureAwait(false);

					item.CopyProperties(updDetail);
				}
			}
			return result;
		}

		public virtual async Task DeleteAsync(int id)
		{
			var entity = await GetByIdAsync(id).ConfigureAwait(false);

			if (entity != null)
			{
				foreach (var item in entity.ManyItems)
				{
					await ManyEntityController.DeleteAsync(item.Id).ConfigureAwait(false);
				}
				await OneEntityController.DeleteAsync(entity.Id).ConfigureAwait(false);
			}
			else
			{
				throw new LogicException(ErrorType.InvalidId);
			}
		}

		public virtual Task SaveChangesAsync()
		{
			return Context.SaveChangesAsync();
		}
		public virtual Task RejectChangesAsync()
		{
			return Context.RejectChangesAsync();
		}
		#endregion Async-Methods

		#region Invoke handler
		public virtual Task InvokeActionAsync(string name, params object[] parameters)
		{
			var helper = new InvokeHelper();

			return helper.InvokeActionAsync(this, name, parameters);
		}
		public virtual Task<object> InvokeFunctionAsync(string name, params object[] parameters)
		{
			var helper = new InvokeHelper();

			return helper.InvokeFunctionAsync(this, name, parameters);
		}
		#endregion Invoke handler

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
			{
				OneEntityController.Dispose();
				ManyEntityController.Dispose();

				OneEntityController = null;
				ManyEntityController = null;
			}
		}
	}
}
//MdEnd
