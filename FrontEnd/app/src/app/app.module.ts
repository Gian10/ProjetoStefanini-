import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CidadeComponent } from './cidade/cidade.component';
import { NavComponent } from './nav/nav.component';
import {HttpClientModule} from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import {routes} from './app-routing.module';




import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { PessoaComponent } from './pessoa/pessoa.component';
import { InicioComponent } from './inicio/inicio.component';

@NgModule({
  declarations: [
    AppComponent,
    CidadeComponent,
    NavComponent,
    PessoaComponent,
    InicioComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),



  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
