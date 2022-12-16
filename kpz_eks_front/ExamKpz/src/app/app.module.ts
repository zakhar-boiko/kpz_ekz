import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LawCaseViewComponent } from './components/law-case-view/law-case-view.component';
import { EditLawCaseComponent } from './components/edit-law-case/edit-law-case.component';
import { EditDocumentComponent } from './components/edit-document/edit-document.component';
import { EditCommentComponent } from './components/edit-comment/edit-comment.component';

const appRoutes = [
  {path: 'LawCases', component: LawCaseViewComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    LawCaseViewComponent,
    EditLawCaseComponent,
    EditDocumentComponent,
    EditCommentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
