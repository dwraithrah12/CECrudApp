import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { UsereditComponent } from './users/useredit/useredit.component';
import { NavbarComponent } from './navbar/navbar.component';
import { GameinfopageComponent } from './gameinfopage/gameinfopage.component';
import { CompanyinfopageComponent } from './companyinfopage/companyinfopage.component';
import { RegistrationpageComponent } from './registrationpage/registrationpage.component';
import { CharacterComponent } from './users/character/character.component';
import { CharacterListComponent } from './users/character/character-list/character-list.component';
import { AppRoutingModule } from './app-routing.module';
import { HomepageComponent } from './homepage/homepage.component';


@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UsereditComponent,
    NavbarComponent,
    GameinfopageComponent,
    CompanyinfopageComponent,
    RegistrationpageComponent,
    CharacterComponent,
    CharacterListComponent,
    HomepageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
