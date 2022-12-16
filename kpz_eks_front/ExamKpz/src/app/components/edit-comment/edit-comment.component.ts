import { Component, Input } from '@angular/core';
import { LawCase } from 'src/app/models/LawCase';
import { Comment } from 'src/app/models/Comment';

@Component({
  selector: 'app-edit-comment',
  templateUrl: './edit-comment.component.html',
  styleUrls: ['./edit-comment.component.css']
})
export class EditCommentComponent {

  @Input() currentLawCase?: LawCase;
  currentComment= new Comment();

  addComment():void{
    this.currentLawCase?.comments?.push(this.currentComment);
    this.currentComment = new Comment();
  }
}
