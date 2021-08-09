import { Button, Col, Input, Row } from 'antd'
import { url } from 'inspector'
import React from 'react'
import { Link } from 'react-router-dom'
import HomeNavBar from './HomeNavBar'

export const HomePage = () => {
    const {Search} = Input;
    return (
        <div>
            <HomeNavBar/>
            {/* <div style = {{backgroundImage : `url(require("assets/travel.jpg"))` }}>  */}
            <div style = {{
                marginTop: '10em',
                background : `url(require("assets/placeholder.png)`
            }}>
                <Row>
                    <Col span = {6}>
                    </Col>
                    <Col span = {12}>
                        <Search 
                        placeholder = "Search business"
                        enterButton = "Search"
                        size = "large"
                        style = {{width: "100%"}}
                        />
                    </Col>
                </Row>
                <div style = {{textAlign: "center", marginTop: "2em"}}>
                    OR
                </div>
                <Link to = '/Businesses'>
                    <Button type = "primary"  
                                style = {{margin: "20px auto", display: "block", width: "200px", height: "50px", background: "orange", border: "orange" }}        
                            >
                                See all businesses
                    </Button>                    
                </Link>

                


            </div>
        </div>
    )
}
