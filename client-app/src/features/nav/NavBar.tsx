import { UserOutlined } from '@ant-design/icons';
import { Breadcrumb, Col, Menu, Row, Input } from 'antd'
import Layout, { Content, Header } from 'antd/lib/layout/layout'
import React, { useContext } from 'react'
import { Link } from 'react-router-dom';
//import BusinessStore from '../../stores/businessStore'

const {Search} = Input;
const NavBar: React.FC = () => {
    //const businessStore = useContext(BusinessStore);
    return (
        <Layout>
            <Header style = {{position: 'fixed', zIndex: 1, width: '100%', backgroundColor: "orange"}}>
                <Row justify = "space-between">
                    <Link to = {"/"}>
                        <Col style = {{color:'white', display: "inline"}} span = {3}>
                            <img src = "logo192.png"
                                    style = {{width: "24px", height: "24px"}}        
                                /> 
                            VIETSPACE
                                
                        </Col>
                    </Link>

                    <Col span = {10} style = {{padding: "10px"}}>
                        <Search placeholder = "Search business" size = "large"/>
                    </Col>
                    <Col style = {{float: "right"}}>
                        <div style = {{backgroundColor: "orange", display: 'flex'}}>
                            <div style = {{marginRight: '20px'}} key = "1" className = "modified-item">
                               <Link to ={"/Businesses"} style = {{color: 'white'}}>
                                   See all posts
                                </Link>
                            </div>
                            
                            <div style = {{marginRight: '20px'}} key = "2" className = "modified-item">
                               <Link to ={"/createBusiness"} style = {{color: 'white'}}>
                                   Advertise
                                </Link>
                            </div>
                            <div style = {{marginRight: '20px'}} key = "3" className = "modified-item">
                                <Link to = {"/contactUs"} style = {{color: 'white'}}>
                                    Contact us
                                </Link>
                            </div>
                            <div key = "4" className = "modified-item">
                                <Link to = {"/"} style = {{color: 'white'}}>
                                    <UserOutlined style = {{marginRight: "5px"}}/>
                                    Login
                                </Link>

                            </div>
                        </div>     

                    </Col>
                </Row>
                

            </Header>           
        </Layout>
    )
}

export default NavBar