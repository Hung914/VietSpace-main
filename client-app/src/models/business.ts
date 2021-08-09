export interface IBusiness {
    id: string; 
    createdDate: Date;
    name: string;
    title: string;
    description: string;
    description2: string;
    description3: string;
    emails: IEmail[];
    phones: IPhone[];
    photos: IPhoto[];
    addresses: IAddress[];
    website: string;
    abn: string;
    categoryId : number; 
    logoImageUrl: string; 

    street: string;
    suburb: string;
    state: string;
    postcode: string;
    number1: string;
    numberDescription1: string;
    number2: string;
    numberDescription2: string;
    
    emailAddress: string;
}

export interface IEmail {
    id : string;
    emailAddress: string;
    description: string;
    businessId: string;
}

export interface IPhone {
    id: string;
    number: string;
    phoneType: number;
    description: string;
    businessId : string;
}

export interface IAddress {
    id: string;
    street: string;
    suburb: string;
    state: string;
    postcode: string;
    businessId: string;
}

export interface IPhoto{
    id: string;
    url : string;
    isMain: boolean;
}

export interface IBusinessDto {
    id: string; 
    createdDate: string;
    name: string;
    title: string;
    description: string;
    description2: string;
    description3: string;
    website: string;
    abn: string;
    categoryId : string; 
    logoImageUrl: string; 


}

// export interface IBusinessFormValues extends Partial<IBusiness>{
// }

// export class BusinessFormValues {
//     id?: string = undefined; 
//     createdDate: string = '';
//     updatedDate: string = '';
//     name: string = '';
//     title: string = '';
//     description: string = '';
//     description2: string = '';
//     description3: string = '';
//     emails: IEmail[] = [];
//     phones: IPhone[] = [];
//     addresses: IAddress[] = [];
//     website: string = '';
//     abn: string = '';
//     categoryId : string = ''; 
//     logoImageUrl: string = ''; 

//     //this to accept and write the input???
//     constructor(init?: IBusinessFormValues){
//         Object.assign(this, init);
//     }
// }