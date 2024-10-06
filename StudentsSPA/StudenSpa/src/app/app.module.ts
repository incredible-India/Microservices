import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';  // <-- Import HttpClientModule
import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ReactiveFormsModule } from '@angular/forms';  // Import ReactiveFormsModule


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    StudentComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule ,
    ReactiveFormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]

})
export class AppModule { }
