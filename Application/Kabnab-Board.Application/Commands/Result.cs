using System;
using System.Collections.Generic;
using System.Text;

namespace Kabnab_Board.Application.Commands
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T? Value { get; private set; }
        public List<string> Errors { get; private set; } = new();

        public static Result<T> Success(T value)
            => new() { IsSuccess = true, Value = value };

        public static Result<T> Failure(List<string> errors)
            => new() { IsSuccess = false, Errors = errors };
    }
}
