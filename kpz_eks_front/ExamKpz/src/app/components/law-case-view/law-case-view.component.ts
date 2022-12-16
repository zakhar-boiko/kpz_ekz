import { Component, Input } from '@angular/core';
import { LawCase } from 'src/app/models/LawCase';
import { LawCaseService } from 'src/app/services/law-case.service';

@Component({
  selector: 'app-law-case-view',
  templateUrl: './law-case-view.component.html',
  styleUrls: ['./law-case-view.component.css']
})
export class LawCaseViewComponent {
  lawCases: LawCase[] = [];
  constructor(private lawCaseService: LawCaseService){

  }
  lawCaseToUpdate?: LawCase;
  searchTerm?: string;
  
  ngOnInit(): void{
    this.lawCaseService
    .getLawCases()
    .subscribe((result: LawCase[]) => (this.lawCases = result));
  }

  initNewLawCase(){
    this.lawCaseToUpdate = new LawCase();
  }

  editLawCase(lawCase: LawCase){
    this.lawCaseToUpdate = lawCase;
  }

  updateLawCaseList(lawCases: LawCase[]){
    this.lawCases = lawCases;
  }


  searchLawCase(){
    if(!(this.searchTerm === undefined || this.searchTerm.length==0)){
      this.lawCaseService.searchByDocument(this.searchTerm??"")
      .subscribe((result: LawCase[]) => (this.lawCases = result));
    } else if(this.searchTerm ==""){
      this.lawCaseService
    .getLawCases()
    .subscribe((result: LawCase[]) => (this.lawCases = result));
    }
  }
}
