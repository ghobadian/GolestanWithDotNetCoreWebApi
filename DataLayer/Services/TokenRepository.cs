using DataLayer.Contexts;
using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services;

public static class TokenRepository
{
    private static readonly Dictionary<string, Token> tokens = new();


    public static IEnumerable<Token> GetAll() => tokens.Values;

    public static Token GetById(string id) => tokens[id];

    public static bool Delete(string id) => tokens.Remove(id);

    public static bool ExistsById(string id) => tokens.ContainsKey(id);


    public static Token Insert(Token entity)
    {
        tokens.Add(entity.Value, entity);
        return entity;
    }
}