using System;
using System.Collections.Generic;
using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using IoTManager.Model;
using IoTManager.Utility.Serializers;
using Microsoft.Extensions.Logging;

namespace IoTManager.Core
{
    public class WorkshopBus: IWorkshopBus
    {
        private readonly IWorkshopDao _workshopDao;
        private readonly ILogger _logger;

        public WorkshopBus(IWorkshopDao workshopDao, ILogger<WorkshopBus> logger)
        {
            this._workshopDao = workshopDao;
            this._logger = logger;
        }
        
        public List<WorkshopSerializer> GetAllWorkshops()
        {
            List<WorkshopModel> workshops = this._workshopDao.Get();
            List<WorkshopSerializer> result = new List<WorkshopSerializer>();
            foreach (WorkshopModel workshop in workshops)
            {
                result.Add(new WorkshopSerializer(workshop));
            }
            return result;
        }

        public WorkshopSerializer GetWorkshopById(int id)
        {
            WorkshopModel workshop = this._workshopDao.GetById(id);
            WorkshopSerializer result = new WorkshopSerializer(workshop);
            return result;
        }

        public String CreateNewWorkshop(WorkshopSerializer workshopSerializer)
        {
            WorkshopModel workshopModel = new WorkshopModel();
            workshopModel.WorkshopName = workshopSerializer.workshopName;
            workshopModel.WorkshopPhoneNumber = workshopSerializer.workshopPhoneNumber;
            workshopModel.WorkshopAddress = workshopSerializer.workshopAddress;
            workshopModel.Remark = workshopSerializer.remark;
            workshopModel.Factory = workshopSerializer.factory;
            return this._workshopDao.Create(workshopModel);
        }

        public String UpdateWorkshop(int id, WorkshopSerializer workshopSerializer)
        {
            WorkshopModel workshopModel = new WorkshopModel();
            workshopModel.Id = workshopSerializer.id;
            workshopModel.WorkshopName = workshopSerializer.workshopName;
            workshopModel.WorkshopPhoneNumber = workshopSerializer.workshopPhoneNumber;
            workshopModel.WorkshopAddress = workshopSerializer.workshopAddress;
            workshopModel.Remark = workshopSerializer.remark;
            workshopModel.Factory = workshopSerializer.factory;
            return this._workshopDao.Update(id, workshopModel);
        }

        public String DeleteWorkshop(int id)
        {
            return this._workshopDao.Delete(id);
        }
    }
}