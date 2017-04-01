var CodeList = React.createClass({

    getInitialState: function () {
        return { data: [] };
    },
    loadData: function(){
        var component = this;
        jQuery.ajax({
            type: "GET",
            url: this.props.url,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (listData) {
                component.setState({ data: listData });
            },
            failure: function (errMsg) {
                alert(errMsg);
            }
        });

    },

    componentWillMount: function () {
        this.loadData();
    },

    render: function () {
        var component = this;
        var codeNodes = this.state.data.map(function(codeItem) {
            return (

              <CodeItem ItemName={codeItem.Name}
                        Description={codeItem.Description}
                        CreatedBy={codeItem.CreatedBy}
                        Program={codeItem.Program}
                        key={codeItem.Id}
                        RecordId={codeItem.Id}
                        Name={codeItem.Name}
                        onItemDeleted={component.loadData}>
              </CodeItem>
            );
        });

        return (
            <div>
                <AddingCodeForm onNewRecord={this.loadData} />
                <div className="codeList">{codeNodes}
                </div>
            </div>
        );
    }
});

//====================================================================================================

ReactDOM.render(
    <CodeList url="/Code/GetCodeList" />,
    document.getElementById('content')
);
