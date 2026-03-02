using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using Core.DAL.Repositories.Concrete.EFCore;
using Entities.Concrete;
using DAL.EFCore;
using DAL.Repositories.Abstract;

namespace DAL.Repositories.Concrete.EFCore;

public class EFCProfileRepository:EFCBaseRepository<Profile,MeetzyDbContext>,IProfileRepository
{
    public EFCProfileRepository(MeetzyDbContext context):base(context)
    {}
}
