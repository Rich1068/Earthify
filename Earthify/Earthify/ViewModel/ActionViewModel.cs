using Earthify.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;

namespace Earthify.ViewModel
{
    public class ActionViewModel
    {
        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }
        public int InsertAction(ActionModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Actionss.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
        public async Task<List<ActionModel>> GetAllAction()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Actionss.ToListAsync();
            return res;
        }
        public async Task<int> UpdateAction(ActionModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Actionss.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int DeleteAction(ActionModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Actionss.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
        public async Task<ActionModel> ViewAction(int id)
        {
            var _dbContext = getContext();
            var action = await _dbContext.Actionss.FindAsync(id);
            return action;
        }

    }
}
