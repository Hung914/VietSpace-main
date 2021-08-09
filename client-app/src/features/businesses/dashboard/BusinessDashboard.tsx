import { Col, Row } from 'antd';
import { observer } from 'mobx-react-lite'
import React, { useContext } from 'react'
import businessStore from '../../../stores/businessStore'
import BusinessList from './BusinessList';

const BusinessDashboard = () => {
    const BusinessStore = useContext(businessStore);
    const {selectedBusiness} = BusinessStore;

    return (
        <div>
            <Row>
                <Col span = {3}></Col>
                <Col span = {15}>
                    <BusinessList/>
                </Col>
            </Row>
            
        </div>
    )
}

export default observer(BusinessDashboard)
