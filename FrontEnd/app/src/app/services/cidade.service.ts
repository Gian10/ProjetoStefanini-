import { Injectable } from '@angular/core';
import {Cidade} from '../models/cidade'
import {environment} from '../../environments/environment'

import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';


@Injectable()
export class CidadeService {

  constructor(private http : HttpClient){}


  get() : Observable<Cidade[]>{
    let response = this.http.get<Cidade[]>(`${environment.api}cidade`)
    return response 
  }

  delete(id : number) : Observable<Number>{
  let response = this.http.delete<Number>(`${environment.api}cidade/${id}`)
  return response
  }


  post(cidade : Cidade): Observable<Cidade>{
  let response = this.http.post<Cidade>(`${environment.api}cidade`, cidade)
  return response  
  }

  put(cidade : Cidade) : Observable<Cidade>{
  let response =  this.http.put<Cidade>(`${environment.api}cidade/${cidade.cidadeId}`, cidade)
  return response
  }

  getId(idCidade : Number) : Observable<Cidade>{
  let response =  this.http.get<Cidade>(`${environment.api}cidade/${idCidade}`)
  return response
  }

  






}
