using DataLayer.Contexts;
using DataLayer.Enums;
using DataLayer.Models.DTOs;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace DataLayer.Services;

public static class TokenRepository
{
    private static readonly Dictionary<string, Token> Tokens = new();


    


    public static IEnumerable<Token> GetAll(int pageNumber, int pageSize) => Tokens.Values.ToPagedList(pageNumber, pageSize);

    public static Token GetById(string id) => Tokens[id];

    public static bool Delete(string id) => Tokens.Remove(id);

    public static bool ExistsById(string id) => Tokens.ContainsKey(id);

    public static bool ExistsByUsername(string username) => Tokens.Values.Any(token => token.Username == username);


    public static Token Insert(Token entity)
    {
        Tokens.Add(entity.Value, entity);
        return entity;
    }
}