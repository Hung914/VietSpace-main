import { observer } from 'mobx-react-lite'
import React, { useContext } from 'react'
import {List, Avatar, Space, Card, Button, Divider, Row, Col, Anchor} from 'antd';
import {MessageOutlined, LikeOutlined, StarOutlined, PhoneFilled, PhoneOutlined, HomeOutlined, MailOutlined, ShopTwoTone} from '@ant-design/icons';
import businessStore from '../../../stores/businessStore';
import { Link } from 'react-router-dom';


const BusinessList: React.FC = () => {
    const BusinessStore = useContext(businessStore);
    const {businessesByDate} = BusinessStore;

    return (
        <List
          itemLayout = "vertical"
          size = "large"
          pagination = {{
              onChange: page => {
                  console.log(page)
              },
              pageSize : 10,
              showQuickJumper: true,
          }}
          dataSource = {businessesByDate}
          renderItem = {business => (
                <Card style = {{marginBottom : "1em"}}>
                <List.Item
                key = {business.name}
                extra = {
                    <div>
                        <img width = {272}
                        alt = "logo"
                        src ={business.photos.url || "assets/placeholder.png"} 
                        />
                        <br></br>
                        <Link to = {`/Businesses/${business.id}`}>
                            <Button type = "primary"  
                                style = {{margin: "20px auto", display: "block", width: "200px", height: "50px", background: "orange", border: "orange" }}        
                            >
                                View Details
                            </Button>
                        </Link>

                    </div>

                }
                >
                    <List.Item.Meta
                        title = {business.name}
                        description = {business.title}
                    />
                    <Divider/>
                    {business.description}
                    <Divider/>
                    <Button type = "primary" shape = "round" size = "large" 
                            style = {{margin: "3px"}}        
                    >
                        <PhoneOutlined/>
                        {business?.phones[0]?.number} 
                    </Button>

                    {business.website !== null && (
                        <Button type = "primary" shape = "round" size = "large"
                        style = {{margin: "3px"}}   
                        onClick = {() => window.open(`//www.${business.website}`)}
                        >
                            <HomeOutlined/>
                            Website 
                        </Button>
                    )}


                    <br></br>
                    <div style = {{marginTop: "3em"}}>
                        {business.emails.length !== 0 && (
                            <div>
                                <MailOutlined style = {{marginRight: '5px'}}/>
                                {business.emails[0]?.emailAddress}
                            </div>

                        )}
                        {business.addresses.length !== 0 && (
                            <div style = {{ marginTop: "5px"}}>
                                <ShopTwoTone style ={{marginRight: "5px"}}/> 
                                {business.addresses[0]?.street} {business.addresses[0]?.suburb} {business.addresses[0]?.state} {business.addresses[0]?.postCode}  
                            
                            </div>
                        )}
                    </div>



                </List.Item>
                </Card>

          )}
        /> 

    )
}

export default observer(BusinessList);