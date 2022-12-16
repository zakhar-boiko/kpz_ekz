import { Component, EventEmitter, Input, Output } from '@angular/core';
import { LawCase } from 'src/app/models/LawCase';
import { LawCaseService } from 'src/app/services/law-case.service';

@Component({
  selector: 'app-edit-law-case',
  templateUrl: './edit-law-case.component.html',
  styleUrls: ['./edit-law-case.component.css']
})
export class EditLawCaseComponent {
  @Input() lawCase?: LawCase;
  @Output() lawCasesUpdated = new EventEmitter<LawCase[]>();
 
  constructor(private lawCaseService: LawCaseService){}

  ngOnInit():void{

  }

  updateLawCase(lawCase: LawCase){
      this.lawCaseService
      .updateLawCase(lawCase)
      .subscribe((lawCases: LawCase[])=>(this.lawCasesUpdated
        .emit(lawCases)))
  }
  deleteLawCase(lawCase: LawCase){
    this.lawCaseService
    .deleteLawCase(lawCase)
    .subscribe((lawCases: LawCase[])=>(this.lawCasesUpdated
      .emit(lawCases)))
  }
  createLawCase(lawCase: LawCase){
    this.lawCaseService
    .createLawCase(lawCase)
    .subscribe((lawCases: LawCase[])=>(this.lawCasesUpdated
      .emit(lawCases)))
  }

}
