import { Component, Input } from '@angular/core';
import { LawCase } from 'src/app/models/LawCase';
import { Document } from 'src/app/models/Document';

@Component({
  selector: 'app-edit-document',
  templateUrl: './edit-document.component.html',
  styleUrls: ['./edit-document.component.css']
})
export class EditDocumentComponent {
  @Input() currentLawCase?: LawCase;
  currentDocument= new Document();

  addDocument():void{
    this.currentLawCase?.documents?.push(this.currentDocument);
    this.currentDocument = new Document();
  }
}
