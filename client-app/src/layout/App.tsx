import React, { useContext, useEffect } from 'react';
import logo from './logo.svg';
import BusinessDashboard from '../features/businesses/dashboard/BusinessDashboard';
import NavBar from '../features/nav/NavBar';
import { observer } from 'mobx-react-lite';
import businessStore from '../stores/businessStore';
import { Route, RouteComponentProps, withRouter, Switch } from 'react-router-dom';
import { HomePage } from '../features/home/HomePage';
import BusinessDetails from '../features/businesses/details/BusinessDetails';
import BusinessForm from '../features/form/BusinessForm';
import { NotFound } from './Errors/NotFound';
import { ServerError } from './Errors/ServerError';
import ContactUs from './ContactUs';

const App : React.FC<RouteComponentProps> = ({ location })=> {
  const BusinessStore = useContext(businessStore); 

  useEffect(() => {
    BusinessStore.loadBusinesses();
  }, [BusinessStore]);
  return (
    <div style = {{background: "#f5f5f5"}}>
      <Route exact path='/' component={HomePage} />
      <Route 
         path = {'/(.+)'}
         render = {() => (
           <div >
             <NavBar/>
             <div style={{ marginTop: '8em' }}>
               <Switch>
                <Route exact path = '/Businesses' component = {BusinessDashboard}/>
                <Route path = '/Businesses/:id' component = {BusinessDetails}/>
                <Route
                    key = {location.key}
                    path = {['/createBusiness']}
                    component = {BusinessForm}
                />    
                <Route path = {['/contactUs']} component = {ContactUs} />
                <Route component = {NotFound}/>
                <Route component = {ServerError}/>
               </Switch>
        
             </div>
             

           </div>
         )
        }
      />
      
      
    </div>

  );
}

export default withRouter(observer(App));
