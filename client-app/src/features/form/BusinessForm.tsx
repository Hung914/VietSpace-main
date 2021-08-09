import { Button, Card, Col, Form, Input, Row } from 'antd';
import { v4 as uuid } from 'uuid';
import { observer } from 'mobx-react-lite'
import React, { FormEvent, useContext, useEffect, useState } from 'react'
import { Form as FinalForm, Field } from 'react-final-form';
import { RouteComponentProps } from 'react-router-dom';
import businessStore from '../../stores/businessStore';
import { IBusiness, IBusinessDto, IEmail } from '../../models/business';

interface DetailParams{
    id: string;
}

const BusinessForm : React.FC<RouteComponentProps<DetailParams>> = ({ match, history}) => {
    const BusinessStore = useContext(businessStore);
    const {
        createBusiness,
        loadBusiness,
        submitting,
        business: initialFormState,
        clearBusiness
    } = BusinessStore;
    
    const [business, setBusiness] = useState<IBusiness>({
        id: '',
        createdDate: new Date(),
        name: '',
        title: '',
        description: '',
        description2: '',
        description3: '',
        emails: [],
        phones: [],
        addresses: [],
        photos: [],
        website: '',
        abn: '',
        categoryId: 0,
        logoImageUrl: '',

        street: '',
        suburb: '',
        state: '',
        postcode: '',
        number1: '',
        numberDescription1: '',
        number2: '',
        numberDescription2: '',
        
        emailAddress: ''

    });

    useEffect(() => {
       if (match.params.id && business.id.length === 0){
           loadBusiness(match.params.id)
               .then(
                   () => initialFormState && setBusiness(initialFormState)
               );
       }
       return () => {
           clearBusiness()
       }
    }, [loadBusiness, match.params.id, initialFormState, business.id.length])

    const handleSubmit = () => {
        if(!business.id){
            let newBusiness = {
                ...business,
                id: uuid()
            };

            business.emails.push({
                id: uuid(),
                emailAddress: business.emailAddress,
                description: "",
                businessId: newBusiness.id
            });
            business.phones.push({
                id: uuid(),
                number: business.number1,
                phoneType: 0,
                description: business.numberDescription1,
                businessId: newBusiness.id
            });
            business.phones.push({
                id: uuid(),
                number: business.number2,
                phoneType: 0,
                description: business.numberDescription2,
                businessId: newBusiness.id
            });
            business.addresses.push({
                id: uuid(),
                street: business.street,
                suburb: business.suburb,
                state: business.state,
                postcode: business.postcode,
                businessId: newBusiness.id
            })
            console.log(newBusiness);
            createBusiness(newBusiness).then(() => history.push(`/Businesses/${newBusiness.id}`));
        }
    }
    const handleInputChange = (
        event: any
    ) => {
        const {name, value, type} = event.currentTarget;
        setBusiness({...business, [name]: value});

    };




    return (
        <div>
            <Row>
                <Col span = {6}/>
                <Col span = {12}>
                    <h1>Business</h1>
                    <Form 
                        onFinish = {handleSubmit} 
                        size = "large"
                        labelCol = {{span: 6}}
                        wrapperCol = {{span: 18}}
                        id = 'submitForm'
                    >
                        <Card title = "Business Details">
                            <Form.Item label = "Name">
                                <Input 
                                   placeholder = "Business Name"
                                   onChange = {handleInputChange}
                                   value = {business.name}
                                   name = 'name'
                                />
                            </Form.Item>
                            <Form.Item label = "Title">
                                <Input 
                                   placeholder = "Business Title"
                                   onChange = {handleInputChange}
                                   value = {business.title}
                                   name = 'title'
                                />
                            </Form.Item>
                            <Form.Item label = "Summary">
                                <Input 
                                   placeholder = "Business Summary"
                                   onChange = {handleInputChange}
                                   value = {business.description}
                                   name = 'description'
                                />
                            </Form.Item>
                            <Form.Item label = "Offered Services">
                                <Input 
                                   placeholder = "Offered Services "
                                   onChange = {handleInputChange}
                                   value = {business.description2}
                                   name = 'description2'
                                />
                            </Form.Item>
                            <Form.Item label = "Description">
                                <Input 
                                   placeholder = "Business Description"
                                   onChange = {handleInputChange}
                                   value = {business.description3}
                                   name = 'description3'
                                />
                            </Form.Item>
                            <Form.Item label = "Website">
                                <Input 
                                   placeholder = "Website"
                                   onChange = {handleInputChange}
                                   value = {business.website}
                                   name = 'website'
                                />
                            </Form.Item>
                            <Form.Item label = "Abn">
                                <Input 
                                   placeholder = "Abn"
                                   onChange = {handleInputChange}
                                   value = {business.abn}
                                   name = 'abn'
                                />
                            </Form.Item>
                        </Card>
                        <Card title = "Address">
                            <Form.Item label = "Street">
                                <Input 
                                   placeholder = "Street"
                                   onChange = {handleInputChange}
                                   value = {business.addresses[0]?.street}
                                   name = 'street'
        
                                />
                            </Form.Item>
                            <Form.Item label = "Suburb">
                                <Input 
                                   placeholder = "Suburb"
                                   onChange = {handleInputChange}
                                   value = {business.addresses[0]?.suburb}
                                   name = 'suburb'
                                />
                            </Form.Item>
                            <Form.Item label = "State">
                                <Input 
                                   placeholder = "State"
                                   onChange = {handleInputChange}
                                   value = {business.addresses[0]?.state}
                                   name = 'state'
                                />
                            </Form.Item>
                            <Form.Item label = "Postcode">
                                <Input 
                                   placeholder = "Postcode"
                                   onChange = {handleInputChange}
                                   value = {business.addresses[0]?.postcode}
                                   name = 'postcode'
                                />
                            </Form.Item>
                        </Card>
                        <Card title = "Contact">
                            <Form.Item label = "Contact Number 1">
                                <Input 
                                   placeholder = "Phone Number"
                                   onChange = {handleInputChange}
                                   value = {business.phones[0]?.number}
                                   name = 'number1'
                                />
                            </Form.Item>
                            <Form.Item label = "Agent 1 Name">
                                <Input 
                                   placeholder = "Full Name"
                                   onChange = {handleInputChange}
                                   value = {business.phones[0]?.description}
                                   name = 'numberDescription1'
                                />
                            </Form.Item>
                            <Form.Item label = "Contact Number 2">
                                <Input 
                                   placeholder = "Phone Number"
                                   onChange = {handleInputChange}
                                   value = {business.phones[1]?.number}
                                   name = 'number2'
                                />
                            </Form.Item>
                            <Form.Item label = "Agent 2 Name">
                                <Input 
                                   placeholder = "Full Name"
                                   onChange = {handleInputChange}
                                   value = {business.phones[1]?.description}
                                   name = 'numberDescription2'
                                />
                            </Form.Item>
                        </Card> 
                        <Card title = "Email">

                            <Form.Item label = "Email">
                                <Input 
                                   placeholder = "Email"
                                   onChange = {handleInputChange}
                                   value = {business.emails[0]?.emailAddress}
                                   name = 'emailAddress'
                                   type = 'email'
                                />
                            </Form.Item>                     
                        </Card>
                        <div style = {{display: "flex", float: "right", marginTop: "1em"}}>
                                <Form.Item>
                                    <Button
                                    type = 'primary'
                                    loading = {submitting}
                                    htmlType = 'submit'
                                    style = {{float: 'right', marginLeft: '2em'}}
                                    >
                                        Submit
                                    </Button>
                                </Form.Item>    
                                <Form.Item>
                                    <Button 
                                    onClick = {() => history.push('/Businesses')}
                                    style = {{float: 'right'}}
                                    >
                                        Cancel
                                    </Button>
                                </Form.Item>       
                            </div>

                    </Form>

                </Col>
            </Row>


        </div>
    )
}

export default observer(BusinessForm);
