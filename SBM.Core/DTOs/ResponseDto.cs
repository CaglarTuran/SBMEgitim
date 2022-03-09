﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Core.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }

        // Static Factory Method

        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T>() { Data = default(T), Errors = null };
        }

        public static ResponseDto<T> Success(int statusCode, T Data)
        {
            return new ResponseDto<T>() { Data = Data, Errors = null };
        }

        public static ResponseDto<T> Fail(int statusCode, string error)
        {
            return new ResponseDto<T>() { Data = default(T), Errors = new List<string>() { error } };
        }

        public static ResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new ResponseDto<T>() { Data = default(T), Errors = errors };
        }
    }
}