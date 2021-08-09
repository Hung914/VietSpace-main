import { action, computed, makeObservable, observable, runInAction } from "mobx";
import { createContext } from "react";
import { history } from "..";
import agent from "../api/agent";
import { IBusiness } from "../models/business";

class BusinessStore{
    constructor(){
        makeObservable(this); //newer mobx requires this to run
    
    }
    @observable businessRegistry = new Map(); 
    @observable business: IBusiness | null = null;
    @observable loadingInitial = false;
    @observable selectedBusiness: IBusiness | undefined;
    @observable submitting = false;


    @computed get businessesByDate(){
        return Array.from(this.businessRegistry.values()).sort(
            (a,b) => Date.parse(a.date) - Date.parse(b.date)
        );
    };

    @action loadBusinesses = async () => {
        this.loadingInitial = true;
        try {
            const businesses = await agent.Businesses.list();
            console.log(businesses);
            runInAction(() => {
                businesses.forEach(business => {
                    business.createdDate = new Date(business.createdDate);
                    this.businessRegistry.set(business.id, business)
                })
            })

        }
        catch (error) {
            runInAction(() => {
                this.loadingInitial = false;
            })
        }
    };

    getBusiness = (id: string) => {
        return this.businessRegistry.get(id);
    }
    @action loadBusiness = async (id: string) => {
        let business = this.getBusiness(id);
        console.log(business);
        if(business){
            this.business = business
            //return to work with form
            return business;
        }
        else{
            this.loadingInitial = true;
            try{
                business = await agent.Businesses.details(id);
                runInAction(() => {
                    this.business = business;
                    this.loadingInitial = false;
                })
                return business;
            }
            catch(error){
                runInAction(() => {
                    this.loadingInitial = false;
                })
                console.log(error);
            }
        }
    }
    @action createBusiness = async (business: IBusiness) => {
        this.submitting = true;
        try {
            await agent.Businesses.create(business);
            runInAction(() => {
                this.businessRegistry.set(business.id, business);
                this.submitting = false;
            })
            history.push(`/Businesses/${business.id}`);
        }
        catch(error){
            runInAction(() => {
                this.submitting = false;
            })
            console.log(error);
        }
    }

    @action clearBusiness = () => {
        this.business = null;
    }
}

export default createContext(new BusinessStore());