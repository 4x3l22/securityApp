using Data.Implemenst;
using Data.Interfaces;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class BusinessView
    {
        private readonly DView dView;

        public BusinessView(DView view)
        {
            this.dView = dView;
        }
        public async Task Delete(int id)
        {
            await this.dView.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.dView.GetAllSelect();
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await this.dView.GetById(id);
            ViewDto viewDto = new ViewDto();

            viewDto.Id = view.Id;
            viewDto.name = view.name;
            viewDto.description = view.description;
            viewDto.route = view.route;
            viewDto.idModule = view.idModule;
            viewDto.state = view.state;

            return viewDto;
        }

        public async Task<View> Save(ViewDto entity)
        {
            View view = new View();
            view = this.mapearDatos(view, entity);

            return await this.dView.Save(view);
        }

        public async Task Update(int id, ViewDto entity)
        {
            View view = await this.dView.GetById(id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            view = this.mapearDatos(view, entity);
            await this.dView.Update(view);
        }

        private View mapearDatos(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.name = entity.name;
            view.description = entity.description;
            view.route = entity.route;
            view.idModule = entity.idModule;
            view.state = entity.state;

            return view;
        }
    }
}
