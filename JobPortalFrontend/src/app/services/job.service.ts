import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Job } from '../models/job.model';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http: HttpClient) { }
  private apiUrl = 'http://localhost:5198/api/Job';

  getJobs(): Observable<Job[]>{
    return this.http.get<Job[]>(this.apiUrl);
  }

  deleteJob(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  addJob(job: Job): Observable<any> {
    return this.http.post<Job>(this.apiUrl, job);
  }

  getJob(id: number): Observable<Job>{
    return this.http.get<Job>(`${this.apiUrl}/${id}`);
  }
  

  updateJob(job: Job): Observable<any>{
    return this.http.put(`${this.apiUrl}/${job.id}`, job);
  }


}
