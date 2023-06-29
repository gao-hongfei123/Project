using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using MyTodo3.Webapi3.Context;
using Todo3.Wpf.Shared;
using Todo3.Wpf.Shared.Dtos;

namespace MyTodo3.Webapi3.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork work,IMapper mapper)
        {
            this.work = work;
            this.mapper = mapper;
        }
        public async  Task<ApiResponse> Login(string account, string password)
        {
            try
            {
                var user = await work.GetRepository<User>().GetFirstOrDefaultAsync(predicate: x => x.Account == account && x.PassWord == password);
                if (user == null)
                {
                    return new ApiResponse(false, "用户不存在");
                }
                else {
                    return new ApiResponse(true, "用户登录成功");
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse(false,ex.Message);
            }
             


        }

        public async  Task<ApiResponse> Register(UserDto user)
        {
            var model = mapper.Map<User>(user);
            try
            {
                var repository = work.GetRepository<User>();
                var flag = await repository.GetFirstOrDefaultAsync(predicate: x=>x.Account==user.Account);
                if (flag != null)
                {
                    return new ApiResponse(false, "账户已存在");
                }
                else
                {
                    await repository.InsertAsync(model);
                    if (await work.SaveChangesAsync() > 0)
                    {
                        return new ApiResponse(true, "注册成功");
                    }
                    else
                    {
                        return new ApiResponse(false, "注册失败");
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
            }
        }
    }
}
