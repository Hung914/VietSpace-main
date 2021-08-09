import { Button, Result } from 'antd'
import React from 'react'
import { Link } from 'react-router-dom'

export const NotFound = () => {
    return (
        <Result
           status = "404"
           title = "404"
           subTitle = "Sorry, the page you visited does not exist."
           extra = {
               <Link to = {'/Businesses'}>
                    <Button>Back To Business List</Button>
               </Link>

           }
        />
    )
}
