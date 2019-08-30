import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JokeResponse, ResultJokeModelResponse } from '../Models/joke.response.model';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'http://localhost:9445/api/Jokes/';
  constructor(private http: HttpClient) {
  }

  // Get a new random joke form API
  getJoke(): Observable<JokeResponse> {
    return this.http.get<JokeResponse>(`${this.baseUrl}RandomJoke`, { headers: { Accept: 'application/json' } });
  }

  // Get jokes containing term
  seachJokesByTerm(searchedTerm: any): Observable<ResultJokeModelResponse> {
    const requestURL = `${this.baseUrl}JokesByTerm/?term=${searchedTerm.searchedValue}`;
    return this.http.get<ResultJokeModelResponse>(requestURL, { headers: { Accept: 'application/json' } });
  }
}
