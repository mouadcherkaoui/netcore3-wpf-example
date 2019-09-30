using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace WPfExample.Data
{
    public interface IContext<TOptions>
        //where TOptions: IOptions<TOptions>
    {
        DbSet<T> Set<T>() where T: class;
        Task<int> CommitChangesAsync();
        TOptions Options { get; }
    }
}