using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using Core.DAL.Repositories.Concrete.EFCore;
using Entities.Concrete;
using DAL.EFCore;
using DAL.Repositories.Abstract;

namespace DAL.Repositories.Concrete.EFCore;

public class EFCMessageRepository:EFCBaseRepository<Message,MeetzyDbContext>,IMessageRepository
{
    public EFCMessageRepository(MeetzyDbContext context):base(context)
    {}
}
