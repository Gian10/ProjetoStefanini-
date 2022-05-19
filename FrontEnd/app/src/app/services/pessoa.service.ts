import { Injectable } from '@angular/core';
import {Pessoa} from '../models/pessoa'
import {environment} from '../../environments/environment'

import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';


@Injectable()
export class PessoaService {

  constructor(private http : HttpClient){}


  get() : Observable<Pessoa[]>{
    let response = this.http.get<Pessoa[]>(`${environment.api}pessoa`)
    return response 
  }

  delete(id : number) : Observable<Number>{
  let response = this.http.delete<Number>(`${environment.api}pessoa/${id}`)
  return response
  }


  post(pessoa : Pessoa): Observable<Pessoa>{
  let response = this.http.post<Pessoa>(`${environment.api}pessoa`, pessoa)
  return response  
  }

  put(pessoa : Pessoa) : Observable<Pessoa>{
  let response =  this.http.put<Pessoa>(`${environment.api}pessoa/${pessoa.pessoaId}`, pessoa)
  return response
  }

  






}
