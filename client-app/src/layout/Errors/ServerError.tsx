import { Button, Result } from 'antd'
import React from 'react'
import { Link } from 'react-router-dom'

export const ServerError = () => {
    return (
        <Result
           status = "500"
           title = "500"
           subTitle = "Sorry, something went wrong"
           extra = {
               <Link to = {'/Businesses'}>
                    <Button>Back To Business List</Button>
               </Link>

           }
        />
    )
}
