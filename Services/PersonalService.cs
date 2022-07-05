using apiRest.Models;
using apiRest.Data;
using Microsoft.EntityFrameworkCore;


namespace apiRest.Services;

public class PersonalService{

    private readonly PersonalContext _context;
    
    public PersonalService(PersonalContext context){
        _context = context;
    }

    public IEnumerable<Personal> GetAll(){
        return _context.Personals.AsNoTracking().ToList();
    }

    public Personal? Get(int Usr_id){
        return _context.Personals.AsNoTracking().SingleOrDefault(p => p.Usr_id == Usr_id);
    }

    public Personal Create(Personal newPersonal){
        _context.Personals.Add(newPersonal);
        _context.SaveChanges();

        return newPersonal;
    }

    public void Update(Personal personal){
        var oldPersonal = _context.Personals.Find(personal.Usr_id);

        if(oldPersonal != null){
            _context.Personals.Remove(oldPersonal);
            _context.Personals.Add(personal);
        }else{
            throw new InvalidOperationException("No existe el elemento buscado");
        }

        _context.SaveChanges();
    }

    public void Delete(int Usr_id){
        var oldPersonal = _context.Personals.Find(Usr_id);

        if(oldPersonal != null){
            _context.Personals.Remove(oldPersonal);
            _context.SaveChanges();
        }else{
            throw new InvalidOperationException("No existe el elemento buscado");
        }
    }
}