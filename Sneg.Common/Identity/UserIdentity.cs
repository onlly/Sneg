using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace Sneg.Common.Identity
{
    public class UserIdentity : ClaimsIdentity
    {
        private readonly Dictionary<Type, object> _infos;

        public UserIdentity(ClaimsIdentity identity):base(identity)
        {
            _infos = new Dictionary<Type, object>();
        }
        public void AddInfo<T>(T part) where T : class
        {
            _infos.Add(typeof(T), part);
        }

        public T GetInfo<T>() where T : class
        {
            if (!_infos.ContainsKey(typeof(T)))
            {
                return default(T);
            }
            return _infos[typeof(T)] as T;
        }

        public int Id
        {
            get
            {
                var userId = this.GetUserId<int>();
                if (userId == 0)
                    throw new InvalidDataException("UserIdentity.Id is 0");
                return userId;
            }
        }
    }
}
