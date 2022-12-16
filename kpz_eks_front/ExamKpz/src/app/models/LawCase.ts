import { Document } from "./Document";
import { Comment } from "./Comment";

export class LawCase{
    id?: number;
    name ="";
    documents= new Array<Document>;
    comments = new Array<Comment>;
}