﻿using Microsoft.EntityFrameworkCore;

namespace BE_CRUDMascotas.Models.Repository
{
    public class MascotaRepository: IMascotaRepository
    {
        private readonly ApplicationDbContext _context;

        public MascotaRepository( ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Mascota> GetMascota(int id)
        {
            return await _context.Mascotas.FindAsync(id);
        }

        public async Task<List<Mascota>> GetListMascotas()
        {         
            return await _context.Mascotas.ToListAsync();
        }

        public async Task DeleteMascota(Mascota mascota)
        {
            _context.Remove(mascota);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Mascota> AddMascota(Mascota mascota)
        {
            _context.Add(mascota);
            await _context.SaveChangesAsync();
            return mascota;
        }

        public async Task UpdateMascota(Mascota mascota)
        {
            var mascotaItem = await GetMascota(mascota.Id);
            if (mascotaItem != null)
            {
                mascotaItem.Nombre = mascota.Nombre;
                mascotaItem.Raza = mascota.Raza;
                mascotaItem.Edad = mascota.Edad;
                mascotaItem.Peso = mascota.Peso;
                mascotaItem.Color = mascota.Color;


                await _context.SaveChangesAsync();
            }
            
        }
    }
}
