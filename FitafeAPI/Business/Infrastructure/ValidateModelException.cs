﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Infrastructure
{
    [Serializable]
    public class ValidateModelException : ArgumentException
    {
        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        public ValidateModelException()
        {
            // Empty constructor required to compile.
        }

        public ValidateModelException(string message)
            : base(message)
        {
        }

        public ValidateModelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ValidateModelException(Dictionary<string, List<string>> errors)
        {
            Errors = errors;
        }

        // The special constructor is used to deserialize values.
        protected ValidateModelException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Reset the property value using the GetValue method.
        }

        // Implement this method to serialize data. The method is called 
        // on serialization.
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            // Use the AddValue method to specify serialized values.
            info.AddValue("props", Errors, typeof(string));
        }

        public List<string> GetErrorString(
            string key)
        {
            Errors.TryGetValue(key, out var errorString);
            return errorString;
        }

        public void Add(
            string key,
            string value)
        {
            Errors.Add(key, value);
        }
    }

    /// <summary>
    /// Throw Not found ref-ult from the http layer. 404
    /// </summary>
    [Serializable]
    public class ItemNotFoundException : ValidateModelException
    {
        public ItemNotFoundException()
        {
        }

        public ItemNotFoundException(string message) : base(message)
        {
        }

        public ItemNotFoundException(Dictionary<string, List<string>> errors) : base(errors)
        {
        }

        public ItemNotFoundException(
            string key,
            string error)
            : base(new Dictionary<string, List<string>>())
        {
            Errors.Add(key, error);
        }

        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message
        {
            get
            {
                var builder = new StringBuilder();
                builder.AppendLine(base.Message);

                foreach (var error in Errors)
                {
                    builder.AppendLine($"{error.Key}: {string.Join(". ", error.Value)}.");
                }

                return builder.ToString();
            }
        }
    }

    /// <summary>
    /// Throw Badrequest from the http layer. 400
    /// </summary>
    [Serializable]
    public class InvalidModelException : ValidateModelException
    {
        public InvalidModelException()
        {
        }

        public InvalidModelException(string message) : base(message)
        {
        }

        public InvalidModelException(Dictionary<string, List<string>> errors) : base(errors)
        {
        }

        public InvalidModelException(
            string key,
            string error)
            : base(new Dictionary<string, List<string>>())
        {
            Errors.Add(key, error);
        }

        public InvalidModelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidModelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class ConflictException : ValidateModelException
    {
        public ConflictException()
        {
        }

        public ConflictException(string message) : base(message)
        {
        }

        public ConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public ConflictException(
            string key,
            string error)
            : base(new Dictionary<string, List<string>>())
        {
            Errors.Add(key, error);
        }

        public ConflictException(Dictionary<string, List<string>> errors)
            : base(errors)
        {
            Errors = errors;
        }
    }

    /// <summary>
    /// Throw forbidden exception from http layer
    /// </summary>
    [Serializable]
    public class InvalidOperationException : ValidateModelException
    {
        public InvalidOperationException()
        {
        }

        public InvalidOperationException(string message) : base(message)
        {
        }

        public InvalidOperationException(Dictionary<string, List<string>> errors) : base(errors)
        {
        }

        public InvalidOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidOperationException(
            string key,
            string error)
            : base(new Dictionary<string, List<string>>())
        {
            Errors.Add(key, error);
        }
    }

    [Serializable]
    public class InvalidEntityIdProvidedException : ValidateModelException
    {
        public InvalidEntityIdProvidedException()
        {
        }

        public InvalidEntityIdProvidedException(string message) : base(message)
        {
        }

        public InvalidEntityIdProvidedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidEntityIdProvidedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public InvalidEntityIdProvidedException(
            string key,
            string error)
            : base(new Dictionary<string, List<string>>())
        {
            Errors.Add(key, error);
        }
    }
}
