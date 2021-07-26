import { CategoriaModel } from './../interfaces/categoria-model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoriaServiceService {

  urlPath : string = "";

  constructor(private httpClient : HttpClient) { 
    this.urlPath += environment.apiUrl + 'categoria';
  }

  add(model : CategoriaModel) : Observable<CategoriaModel> {
    return this.httpClient.post<CategoriaModel>(this.urlPath, model);
  }

  update(model : CategoriaModel) : Observable<CategoriaModel> {
    return this.httpClient.patch<CategoriaModel>(this.urlPath, model);
  }

  getAll() : Observable<CategoriaModel[]> {
    return this.httpClient.get<CategoriaModel[]>(this.urlPath);
  }

  getById(id : number) : Observable<CategoriaModel> {
    return this.httpClient.get<CategoriaModel>(this.urlPath + '/' + id.toString());
  }

  delete(id : number) : Observable<any> {
    return this.httpClient.delete(this.urlPath + '/' + id.toString());
  }
}
