import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ProdutoModel } from '../interfaces/produto-model';

@Injectable({
  providedIn: 'root'
})
export class ProdutoServiceService {

  urlPath : string = "";

  constructor(private httpClient : HttpClient) { 
    this.urlPath += environment.apiUrl + 'produto';
  }

  add(model : ProdutoModel) : Observable<ProdutoModel> {
    return this.httpClient.post<ProdutoModel>(this.urlPath, model);
  }

  update(model : ProdutoModel) : Observable<ProdutoModel> {
    return this.httpClient.patch<ProdutoModel>(this.urlPath, model);
  }

  getAll() : Observable<ProdutoModel[]> {
    return this.httpClient.get<ProdutoModel[]>(this.urlPath);
  }

  getById(id : number) : Observable<ProdutoModel> {
    return this.httpClient.get<ProdutoModel>(this.urlPath + '/' + id.toString());
  }

  delete(id : number) : Observable<any> {
    return this.httpClient.delete(this.urlPath + '/' + id.toString());
  }
}
