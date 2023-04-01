
using DataLayer.Models;
using DataLayer.Repositories;
using Golestan.Services.Interfaces;

namespace Golestan.Services;

public class TermService : ITermService {
    private readonly ITermRepository termRepository;

    public TermService(ITermRepository termRepository)
    {
        this.termRepository = termRepository;
    }

    public IEnumerable<Term> List(/*int page, int number*/) 
    {
        return termRepository.GetAll(/*page, number*/);
    }

    public Term Create(string title, bool open)
    {
        var term = new Term { Title = title, Open = open };
        //log.info("Term with title: " + title + " created");
        termRepository.Insert(term);
        termRepository.Save();
        return term;
    }

    public Term Read(int termId) => termRepository.GetById(termId);

    public Term Update(string title, bool? open, int termId)
    {
        var term = Read(termId);
        ChangeTitle(title, term);
        ChangeOpen(open, term);
        termRepository.Update(term);
        termRepository.Save();
        return term;
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
        //log.info("Term with title: " + term.getTitle() + " Deleted");
    }
}
