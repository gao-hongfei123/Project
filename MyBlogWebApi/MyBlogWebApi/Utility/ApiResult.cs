﻿namespace MyBlogWebApi.Utility
{
        public class ApiResult
        {
            public int Code { get; set; }
            public string? Message { get; set; }
            public int Total { get; set; }
            public dynamic? Data { get; set; }

        }
    
}
