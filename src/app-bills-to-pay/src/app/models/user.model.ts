export class User {
    constructor(
        public _id: string | null,
        public name: string,       
        public userName: string,
        public email: string | null,
        public password: string | null,
    ){

    }    
}