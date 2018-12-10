using System.Collections.Generic;

namespace ModisAPI.Models.WorkerServices
{
    public interface IWorkerServicesStudenti
    {
        List<Studente> RestituisciListaStudenti();
        Studente RestituisciStudente(int id);
        int Registrazione(int id, string nome, string cognome);
    }
}