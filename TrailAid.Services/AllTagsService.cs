﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.AllTags;

namespace TrailAid.Services
{
    public class AllTagsService
    {
        public bool CreateAllTags(AllTagsCreate model)
        {
            var entity = new AllTags()
            {
                ListOfAllTags = model.ListOfAllTags,
                
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AllTags.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AllTagsDetail> GetAllTags()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.AllTags.Select
                    (e => new AllTagsDetail
                    {
                        ListOfAllTags = e.ListOfAllTags, 
                    }
                    );
                return query.ToArray();
            }

        }
        public bool UpdateAllTags(AllTagsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.AllTags.Single();

                entity.ListOfAllTags = model.ListOfAllTags;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
