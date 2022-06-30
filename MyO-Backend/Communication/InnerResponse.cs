﻿namespace MyO_Backend.Communication
{
    public class InnerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public InnerResponse(bool success, string message, object? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
