﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using DDD5c.DAL;
using DDD5c.Areas.Seguranca.Models;

namespace DDD5c.Infraestrutura
{
    public class GerenciadorUsuario : UserManager<Usuario>
    {
        public GerenciadorUsuario(IUserStore<Usuario> store) : base(store)
        {
        }
        public static GerenciadorUsuario Create(
        IdentityFactoryOptions<GerenciadorUsuario> options,
        IOwinContext context)
        {
            IdentityDbContextAplicacao db = context.Get
            <IdentityDbContextAplicacao>();
            GerenciadorUsuario manager = new GerenciadorUsuario(
            new UserStore<Usuario>(db));
            return manager;
        }
    }
}