import { UserOutlined } from '@ant-design/icons';
import { Breadcrumb, Col, Menu, Row, Input } from 'antd'
import Layout, { Content, Header } from 'antd/lib/layout/layout'
import React, { useContext } from 'react'
import { Link } from 'react-router-dom';
//import BusinessStore from '../../stores/businessStore'

const {Search} = Input;
const HomeNavBar: React.FC = () => {
    //const businessStore = useContext(BusinessStore);
    return (
        <Layout>
            <Header style = {{position: 'fixed', zIndex: 1, width: '100%', backgroundColor: "orange"}}>
                <Row justify = "space-between">
                    <Col style = {{color:'white'}} span = {3}>
                        <img src = "logo192.png"
                                style = {{width: "24px", height: "24px"}}        
                            />
                            VIETSPACE
                    </Col>
                    <Col style = {{float: "right"}}>
                        <div style = {{backgroundColor: "orange", display: "flex"}}>
                            <div><Link to ={"/createBusiness"} style = {{color: 'white', marginRight: '20px'}}>
                                Post an ad
                            </Link></div>
                            <div key = "2" style = {{float: "right"}}>
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

export default HomeNavBar