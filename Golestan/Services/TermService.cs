
using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Repositories;
using Golestan.Services.Interfaces;
using Golestan.Utils;

namespace Golestan.Services;

public class TermService : ITermService {
    private readonly ITermRepository termRepository;
    private readonly ILogger<TermService> logger;//todo check other github projects to add more features

    public TermService(ITermRepository termRepository, ILogger<TermService> logger)
    {
        this.termRepository = termRepository;
        this.logger = logger;
    }

    public IEnumerable<TermOutputDto> List(/*int page, int number*/) 
    {
        return termRepository.GetAll(/*page, number*/).Select(term => term.OutputDto());
    }

    public TermOutputDto Create(TermInputDto newTerm)
    {
        var term = new Term { Title = newTerm.Title, Open = newTerm.Open.Value };
        logger.LogInformation("Term with title: \" + title + \" created");
        termRepository.Insert(term);
        termRepository.Save();
        return term.OutputDto();
    }

    public TermOutputDto Read(int termId) => termRepository.GetById(termId).OutputDto();

    public TermOutputDto Update(int termId, TermInputDto newTerm)
    {
        var term = termRepository.GetById(termId);
        ChangeTitle(newTerm.Title, term);
        ChangeOpen(newTerm.Open, term);
        termRepository.Update(term);
        termRepository.Save();
        return term.OutputDto();
    }

    private static void ChangeOpen(bool? open, Term term) {
        if (open != null)
        {
            term.Open = open.Value;
        }
    }

    private static void ChangeTitle(string? title, Term term) {
        if (title !=null) {
            term.Title = title;
        }
    }

    public void Delete(int id) 
    {
        termRepository.Delete(id);
        termRepository.Save();
        logger.LogInformation("Term with title: \" + newTerm.getTitle() + \" Deleted");
    }
}
