using SchoolMgmtWEB_326.Helpers.Helpers;
using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Models.Models;
using SchoolMgmtWEB_326.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    public class UserAPIController : ApiController
    {
        OrderManagementEntities entities = new OrderManagementEntities();

        [HttpGet]
        [Route("api/UserAPI/DisplayUsers")]
        public async Task<IHttpActionResult> Read()
        {
            try
            {
                entities.Configuration.ProxyCreationEnabled = false;
                List<Users> users = await entities.Users.ToListAsync();
                if (users != null && users.Count() > 0)
                {
                    List<UserModel> uModel = UserHelper.BindUserModelListToList(users);

                    return Ok(uModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IHttpActionResult> GetDetails(int? Id)
        {
            try
            {
                Users users = await entities.Users.Where(m => m.Id == Id).FirstOrDefaultAsync();
                UserModel userModel = UserHelper.BindUserToUserModel(users);
                if (userModel != null)
                {
                    return Ok(userModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        [Route("api/UserAPI/AddEditUser")]
        public async Task<int> post(UserModel userModel)
        {
            try
            {
                Users users = UserHelper.BindUserModelToUser(userModel);
                if (userModel.Id == 0)
                {
                    var checkUser = await entities.Users.AnyAsync(m => m.FirstName == userModel.FirstName && m.LastName == userModel.LastName);
                    if (checkUser)
                    {
                        return 0;
                    }
                    else
                    {
                        entities.Users.Add(users);
                        await entities.SaveChangesAsync();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(users).State = EntityState.Modified;
                    await entities.SaveChangesAsync();
                    return 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

 

        [HttpDelete]
        public async Task<int> Delete(int Id)
        {
            try
            {
                var res = await entities.Users.Where(m => m.Id == Id).FirstOrDefaultAsync();
                if (res != null)
                {
                    entities.Users.Remove(res);
                    await entities.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
