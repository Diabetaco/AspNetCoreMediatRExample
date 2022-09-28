using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook;

public class DeleteAddressHandler
        : IRequestHandler<DeleteAddressRequest, Guid>
{
    private readonly IRepo<AddressBookEntry> _repo;

    public DeleteAddressHandler(IRepo<AddressBookEntry> repo)
    {
        _repo = repo;
    }


    public async Task<Guid> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<AddressBookEntry> entry = _repo.Find(new EntryByIdSpecification(request.Id));

        _repo.Remove(entry.ElementAt(0));
        return await Task.FromResult(request.Id);
    }
}
