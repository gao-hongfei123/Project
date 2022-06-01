using SqlSugar;

namespace MyBlogWebApi.Utility
{
    public static class ApiResultHelper
    {
        public static ApiResult Success(dynamic data) {
            return new ApiResult()
            {
                Code = 200,
                Data = data,
                Message="操作成功 ",
                Total=0
                
            };
        }
        public static ApiResult Success(dynamic data,RefAsync<int> page) {
            return new ApiResult()
            {
                Code = 200,
                Data = data,
                Message = "操作成功",
                Total = page
            };
            
        }
        public static ApiResult Error(dynamic data) {
            return new ApiResult()
            {
                Code = 404,
                Data = data,
                Message = "操作失败",
                Total = 0

            };
        }

    }

    
}
