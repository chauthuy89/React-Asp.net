﻿import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Modal, Button } from 'semantic-ui-react';

export default class CustomerDelete extends Component {
    constructor(props) {
        super(props);
        this.state = {
            
        };

        this.onDeleteSubmit = this.onDeleteSubmit.bind(this);
        this.onClose = this.onClose.bind(this);
        //this.delete = this.delete.bind(this);//
    }
    
    onDeleteSubmit(id) {
        $.ajax({
            url: "/Customer/DeleteCustomer",
            type: "post",
            data: { 'id': id },
            success: function (data) {
                this.setState({ success: data })
            window.location.reload()
            }.bind(this)
        });
       
    }
    //delete = () => {
    //    this.props.delete({ Id: this.props.id, Name: this.state.name, Address: this.state.address });
    //    this.handleClose();//
    //}

    onClose() {
        this.setState({ showDeleteModal: false });
        window.location.reload()
    }

    render() {
        
        return (            
            <React.Fragment>
                <Modal open={this.props.showDeleteModal} onClose={this.props.onClose} size='small'>
                    <Modal.Header>Delete Customer</Modal.Header>
                    <Modal.Content>
                        <h3>
                            Are you sure?
                        </h3>
                    </Modal.Content>
                    <Modal.Actions>
                        <Button onClick={this.props.onClose} secondary >Cancel
                            </Button>
                        <Button onClick={() => this.onDeleteSubmit(this.props.delete)} className="ui red button"> Delete <i className="x icon"></i>
                           
                        </Button>
                    
                    </Modal.Actions>
                </Modal>
            </React.Fragment>
        )
    }
}