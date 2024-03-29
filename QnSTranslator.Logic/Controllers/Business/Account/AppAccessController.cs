//@QnSCodeCopy
//MdStart
using System;
using System.Linq;
using System.Threading.Tasks;
using CommonBase.Extensions;
using QnSTranslator.Contracts.Business.Account;
using QnSTranslator.Logic.Controllers.Persistence.Account;
using QnSTranslator.Logic.Entities.Business.Account;
using QnSTranslator.Logic.Entities.Persistence.Account;

namespace QnSTranslator.Logic.Controllers.Business.Account
{
    internal partial class AppAccessController
    {
        private IdentityXRoleController IdentityXRoleController { get; set; }

        partial void Constructed()
        {
            IdentityXRoleController = new IdentityXRoleController(this);
            ChangedSessionToken += AppAccessController_ChangedSessionToken;
        }

        private void AppAccessController_ChangedSessionToken(object sender, EventArgs e)
        {
            IdentityXRoleController.SessionToken = SessionToken;
        }

        protected override async Task LoadDetailsAsync(AppAccess entity, int masterId)
        {
            entity.ClearManyItems();
            foreach (var item in IdentityXRoleController.ExecuteQuery(p => p.IdentityId == masterId).ToList())
            {
                var role = await ManyEntityController.GetByIdAsync(item.RoleId).ConfigureAwait(false);

                if (role != null)
                {
                    entity.AddManyItem(role);
                }
            }
        }

        public override async Task<IAppAccess> InsertAsync(IAppAccess entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.OneItem.CheckArgument(nameof(entity.OneItem));
            entity.ManyItems.CheckArgument(nameof(entity.ManyItems));

            var result = new AppAccess();

            result.FirstEntity.CopyProperties(entity.OneItem);
            await OneEntityController.InsertAsync(result.FirstEntity).ConfigureAwait(false);

            foreach (var item in entity.ManyItems)
            {
                var role = new Role();
                var joinRole = new IdentityXRole();

                joinRole.Identity = result.FirstEntity;
                if (item.Id == 0)
                {
                    item.Designation = RoleController.ClearRoleDesignation(item.Designation);

                    var qryItem = ManyEntityController.ExecuteQuery(e => e.Designation.Equals(item.Designation)).FirstOrDefault();

                    if (qryItem != null)
                    {
                        role.CopyProperties(qryItem);
                        joinRole.RoleId = role.Id;
                    }
                    else
                    {
                        role.CopyProperties(item);
                        await ManyEntityController.InsertAsync(role).ConfigureAwait(false);
                        joinRole.Role = role;
                    }
                }
                else
                {
                    var qryItem = await ManyEntityController.GetByIdAsync(item.Id).ConfigureAwait(false);

                    if (qryItem != null)
                    {
                        role.CopyProperties(qryItem);
                    }
                    joinRole.RoleId = role.Id;
                }
                await IdentityXRoleController.InsertAsync(joinRole).ConfigureAwait(false);
                result.AddManyItem(role);
            }
            return result;
        }
        public override async Task<IAppAccess> UpdateAsync(IAppAccess entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.OneItem.CheckArgument(nameof(entity.OneItem));
            entity.ManyItems.CheckArgument(nameof(entity.ManyItems));

            var accessRoles = entity.ManyItems.Select(i =>
            {
                var entity = new Role();

                i.Designation = RoleController.ClearRoleDesignation(i.Designation);
                if (entity.Id == 0)
                {
                    var role = ManyEntityController.ExecuteQuery(e => e.Designation.Equals(i.Designation))
                                                   .FirstOrDefault();
                    if (role != null)
                    {
                        entity.CopyProperties(role);
                    }
                }
                return entity;
            });

            //Delete all costs that are no longer included in the list.
            var identityXRoles = await IdentityXRoleController.ExecuteQueryAllAsync(e => e.IdentityId == entity.Id).ConfigureAwait(false);

            foreach (var item in identityXRoles)
            {
                var stillHasTheRole = accessRoles.Any(i => i.Id == item.RoleId);

                if (stillHasTheRole == false)
                {
                    await IdentityXRoleController.DeleteAsync(item.Id).ConfigureAwait(false);
                }
            }

            var result = new AppAccess();
            var firstEntity = await OneEntityController.UpdateAsync(entity.OneItem).ConfigureAwait(false);

            result.OneItem.CopyProperties(firstEntity);
            foreach (var accessRole in accessRoles)
            {
                var role = new Role();
                var joinRole = new IdentityXRole();

                role.Id = accessRole.Id;
                joinRole.IdentityId = firstEntity.Id;
                if (accessRole.Id == 0)
                {
                    role.CopyProperties(accessRole);
                    await ManyEntityController.InsertAsync(role).ConfigureAwait(false);
                    joinRole.Role = role;
                }
                else
                {
                    var qryRole = await ManyEntityController.GetByIdAsync(role.Id).ConfigureAwait(false);

                    if (qryRole != null)
                    {
                        role.CopyProperties(qryRole);
                        joinRole.RoleId = role.Id;
                    }
                }
                var identityXRole = identityXRoles.SingleOrDefault(e => e.IdentityId == joinRole.IdentityId && e.RoleId == joinRole.RoleId);

                if (identityXRole == null)
                {
                    await IdentityXRoleController.InsertAsync(joinRole).ConfigureAwait(false);
                }
                result.AddManyItem(role);
            }
            return result;
        }
        public override async Task DeleteAsync(int id)
        {
            //Delete all costs that are no longer included in the list.
            var identXRoles = await IdentityXRoleController.ExecuteQueryAllAsync(e => e.IdentityId == id);

            foreach (var item in identXRoles)
            {
                await IdentityXRoleController.DeleteAsync(item.Id).ConfigureAwait(false);
            }
            await OneEntityController.DeleteAsync(id).ConfigureAwait(false);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            IdentityXRoleController.Dispose();

            IdentityXRoleController = null;
        }
    }
}
//MdENd
