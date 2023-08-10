import PropTypes from 'prop-types';
import React, { useEffect, useState, useCallback } from 'react';
import { useFocusEffect } from '@react-navigation/native';
import {
  createTenant,
  getTenantById,
  removeTenant,
  updateTenant,
  getEditions,
} from '../../api/SaasAPI';
import LoadingActions from '../../store/actions/LoadingActions';
import { createLoadingSelector } from '../../store/selectors/LoadingSelectors';
import { connectToRedux } from '../../utils/ReduxConnect';
import CreateUpdateTenantForm from './CreateUpdateTenantForm';

function CreateUpdateTenantScreen({ navigation, route, startLoading, stopLoading }) {
  const [tenant, setTenant] = useState();
  const [editions, setEditions] = useState();
  const tenantId = route.params?.tenantId;

  const remove = () => {
    startLoading({ key: 'removeTenant' });
    removeTenant(tenantId)
      .then(() => navigation.goBack())
      .finally(() => stopLoading({ key: 'removeTenant' }));
  };

  useFocusEffect(
    useCallback(() => {
      if (tenantId) {
        getTenantById(tenantId).then((data = {}) => setTenant(data));
      }
      getEditions().then(data => setEditions(data));
    }, []),
  );

  const submit = data => {
    startLoading({ key: 'saveTenant' });
    let request;
    if (data.id) {
      request = updateTenant(data, tenantId);
    } else {
      request = createTenant(data);
    }

    request
      .then(() => {
        navigation.goBack();
      })
      .finally(() => stopLoading({ key: 'saveTenant' }));
  };

  const renderForm = () => (
    <CreateUpdateTenantForm
      editingTenant={tenant}
      editions={editions && editions.totalCount > 0 ? editions.items : []}
      submit={submit}
      remove={remove}
    />
  );

  if (tenantId && tenant) {
    return renderForm();
  }

  if (!tenantId) {
    return renderForm();
  }

  return null;
}

CreateUpdateTenantScreen.propTypes = {
  startLoading: PropTypes.func.isRequired,
  stopLoading: PropTypes.func.isRequired,
};

export default connectToRedux({
  component: CreateUpdateTenantScreen,
  stateProps: state => ({ loading: createLoadingSelector()(state) }),
  dispatchProps: {
    startLoading: LoadingActions.start,
    stopLoading: LoadingActions.stop,
  },
});
